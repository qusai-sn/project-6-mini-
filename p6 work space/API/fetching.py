import requests
import json

# Your API token
API_TOKEN = 'YOUR_API_TOKEN'
BASE_URL = 'http://api.menus.nypl.org'

# Function to fetch all menus
def fetch_menus():
    url = f'{BASE_URL}/menus?token={API_TOKEN}&per_page=50'
    response = requests.get(url)
    
    if response.status_code == 200:
        return response.json()
    else:
        print(f"Failed to fetch menus. Status code: {response.status_code}")
        return None

# Function to fetch dishes for a specific menu
def fetch_dishes(menu_id):
    url = f'{BASE_URL}/menus/{menu_id}/dishes?token={API_TOKEN}'
    response = requests.get(url)
    
    if response.status_code == 200:
        return response.json()
    else:
        print(f"Failed to fetch dishes for menu {menu_id}. Status code: {response.status_code}")
        return None

# Function to fetch a dish's details by ID
def fetch_dish_details(dish_id):
    url = f'{BASE_URL}/dishes/{dish_id}?token={API_TOKEN}'
    response = requests.get(url)
    
    if response.status_code == 200:
        return response.json()
    else:
        print(f"Failed to fetch details for dish {dish_id}. Status code: {response.status_code}")
        return None

# Process and store the data
def process_and_store_data():
    menus = fetch_menus()
    
    if menus is None or 'menus' not in menus:
        print("No menus found or invalid response structure.")
        return
    
    processed_data = []

    for menu in menus['menus']:
        dishes = fetch_dishes(menu['id'])
        
        if dishes is None or 'dishes' not in dishes:
            print(f"No dishes found for menu {menu['id']}.")
            continue
        
        for dish in dishes['dishes']:
            dish_details = fetch_dish_details(dish['id'])
            
            if dish_details is None:
                continue
            
            processed_dish = {
                "name": dish_details.get('name', 'N/A'),
                "price": dish_details.get('lowest_price', 'N/A'),
                "event": menu.get('event', 'N/A'),
                "venue": menu.get('venue', 'N/A'),
                "location": menu.get('location', 'N/A'),
                "date": menu.get('date', 'N/A'),
                "thumbnail": menu.get('thumbnail_src', ''),
                "nutrition": {
                    "calories": 500,  # Placeholder values
                    "protein": 25,
                    "carbs": 50,
                    "fat": 20
                }
            }
            
            processed_data.append(processed_dish)
    
    # Save to a new JSON file
    new_file_name = 'processed_meals_data_v2.json'
    with open(new_file_name, 'w') as f:
        json.dump(processed_data, f, indent=4)
    
    print(f"Processed data saved to {new_file_name}")

# Run the function to fetch and process the data
process_and_store_data()

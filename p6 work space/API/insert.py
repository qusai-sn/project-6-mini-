import json
import pyodbc

# Load the JSON data
file_path = 'modified_meals_data.json'  # Replace with your actual file path
with open(file_path, 'r') as file:
    meals_data = json.load(file)

# Connect to the SQL Server database
connection_string = 'DRIVER={SQL Server};SERVER=DESKTOP-GIEQN5M;DATABASE=Fresh_and_Fit;Trusted_Connection=yes;'
conn = pyodbc.connect(connection_string)
cursor = conn.cursor()

# Insert data into the Meals table
insert_query = """
INSERT INTO Meals (Name, Price, Description, ImageUrl, Calories, Protein, Carbs, Fat, QuantityInStock, DietType)
VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
"""

for meal in meals_data:
    QuantityInStock = 100  # Default value for QuantityInStock
    
    cursor.execute(
        insert_query,
        meal['strMeal'],
        meal['Price'],
        meal.get('strTags', ''),  # Using strTags as Description
        meal['strMealThumb'],
        meal['nutrition']['calories'],
        meal['nutrition']['protein'],
        meal['nutrition']['carbs'],
        meal['nutrition']['fat'],
        QuantityInStock,
        meal['dietType']  # Inserting DietType as a string
    )
    print("done")

# Commit the transaction
conn.commit()

# Close the connection
conn.close()

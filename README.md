# Darren Stander St10209886.Prog6221POEPart1
# https://github.com/Darren-Stander/ProgPart1.git
# Commit Screenshots
![Screenshot 2024-04-16 081748](https://github.com/Darren-Stander/ProgPart1/assets/163761702/86de50f7-e609-4722-9ea3-7ced3b20cba3)

# Reference
F. (2024, March 4). Learn C# Programming – Full Course with Mini-Projects. YouTube. https://www.youtube.com/watch?v=YrtFtdTTfv0
I. (2018, February 23). Handling Exceptions in C# - When to catch them, where to catch them, and how to catch them. YouTube. https://www.youtube.com/watch?v=LSkbnpjCEkk
T. (2018, February 5). C# - Arrays. YouTube. https://www.youtube.com/watch?v=daFdTssjm3w
P. W. M. (2016, April 3). C# Tutorial For Beginners - Learn C# Basics in 1 Hour. YouTube. https://www.youtube.com/watch?v=gfkTfcpWqAY
M. (2024, January 12). Adding a Submenu to a Menu - Visual Studio (Windows). Microsoft Learn. https://learn.microsoft.com/en-us/visualstudio/extensibility/adding-a-submenu-to-a-menu?view=vs-2022


# How to run code
# Recipe Manager Console App
This is a simple console application designed to manage recipes. You can create, view, scale, reset, and delete recipes using this app.

# Features
Enter Ingredients: Allows you to enter the ingredients for your recipe.
Enter Steps: Lets you input the steps to make your recipe.
View Recipe: Displays the current recipe details.
Scale Recipe: Scales the recipe by a specified factor.
Reset Scale: Resets any scaling adjustments made to the recipe.
Delete Recipe: Deletes the current recipe.
Close App: Exits the application.

# How to Run
# Prerequisites
.NET SDK installed on your machine

# Steps to Run
Download the Zip File:

# Download the zip file containing the source code and extract it to your desired location.
Navigate to the Project Directory:

# Open a terminal or command prompt and navigate to the directory where you extracted the zip file.
Compile and Run the App:

Run the following commands to compile and execute the application:

# On Windows:
Locate the Zip File:

# Navigate to the folder where the zip file is located.

# Extract the Zip File:

# Right-click on the zip file.
Select "Extract All..." from the context menu.
Choose a destination folder to extract the contents.
Click "Extract".

# On macOS:
Locate the Zip File:
Navigate to the folder where the zip file is located.
Extract the Zip File:
Double-click on the zip file.
The contents will be automatically extracted to a folder with the same name as the zip file.

# Install Microsoft Visual Studio

# On Windows:
Download Visual Studio Installer:
Visit the Visual Studio Downloads page.
Click on the "Download Visual Studio" button to download the installer.
Run the Installer:

# Locate the downloaded installer (usually in the Downloads folder).
Double-click on the installer to run it.
Select Workloads:

# In the installer, you can select the workloads you want to install (e.g., .NET desktop development, ASP.NET development).
Choose the workloads that fit your needs and click "Install".
Follow the Installation Wizard:

# Follow the on-screen instructions to complete the installation.
Visual Studio will be installed with the selected workloads.

# Part 2

## using MS Visual Studio .Net 4.8
## Darren Stander St10209886.Prog6221POEPart1
## https://github.com/Darren-Stander/ProgPart1.git


![Screenshot 2024-05-30 202953](https://github.com/Darren-Stander/ProgPart1/assets/163761702/0ed3dcfb-182d-4754-a9bc-3d8a97fd5de3)



# How to compile and run the code 

## Get the Code:

Think of GitHub as a big library of code. We need to take a copy of the code from there and put it on our own computer. This is called "cloning" the repository.

Go to the GitHub page of the project you want to work on.

Look for a green button that says "Code" and click on it. Then, select "Download ZIP".

Once it's downloaded, unzip the file. Now, you have the code on your computer!

## Open Visual Studio:

Visual Studio is a program on your computer where we'll work with the code.

Look for the Visual Studio icon on your desktop or in your Start menu. It's a colorful square with the letters "VS" inside.

Click on it to open the program. It might take a moment to load.

## Open the Project:

When Visual Studio opens, you'll see a window with options to create a new project or open an existing one.

Choose the option that says "Open a project or solution." It's usually in the middle of the window.

Now, we need to find the folder where you put the code you downloaded from GitHub.

Click on "Browse" and navigate to that folder. Inside, you should see a file that ends with ".sln". This is the project file.

Click on the ".sln" file and then click "Open." Visual Studio will now load the project.

## Prepare the Project:

Sometimes, the code we downloaded needs extra pieces to work properly. These are called dependencies.

Visual Studio will often help us with this. It might pop up a message saying something like "This project is missing some components. Do you want to install them?"

If you see this message, just click "Yes" or "OK." Visual Studio will take care of the rest, downloading and installing what's needed.

## Build the Code:

Building the code is like putting all the pieces of a puzzle together to make a picture.

Go to the "Build" menu at the top of Visual Studio. It's next to "File" and "Edit."

Click on "Build Solution." You might also see an icon that looks like a hammer - you can click on that too.

Visual Studio will now go through the code and turn it into something the computer can understand. This might take a minute or two.

## Run the Code:

Now that we've built the code, it's time to see it in action!

Go to the "Debug" menu at the top of Visual Studio.

Choose "Start Debugging." You might also see a green arrow icon that does the same thing - you can click on that too.

Visual Studio will now run the code, and you should see the results on your screen.

## Explore and Learn:

You did it! You've compiled and run a project from GitHub in Visual Studio.

Take some time to explore the code. Try changing things and see what happens. This is how we learn and get better at coding!

If you run into any problems, don't worry. It's all part of the learning process. Just keep experimenting and asking questions, and you'll get there.


# Changes ive made to the code for part 2
In creating a software system that allows users to add an unlimited number of recipes, organize them alphabetically, input calories for each ingredient, categorize ingredients by food group, and calculate total calories while notifying users if a recipe exceeds 300 calories, several key design principles and functionalities must be considered.

Firstly, the software architecture should facilitate dynamic storage of recipes and their ingredients. Utilizing a database structure enables efficient retrieval and manipulation of data. Each recipe can be represented as an object containing attributes such as name, ingredients, and their respective calorie values.

Secondly, an intuitive user interface is essential. Users should be able to easily add, edit, and view recipes. A searchable and sortable list displaying recipes alphabetically streamlines navigation.

Thirdly, incorporating a calorie tracker for ingredients ensures accurate nutritional information. Users can input the calorie count for each ingredient, with an option to assign them to specific food groups like proteins, carbohydrates, fats, etc.

Lastly, implementing a calorie calculator function enables the software to compute the total calorie content of a recipe. If the sum exceeds 300 calories, the system promptly notifies the user, promoting awareness of nutritional intake.

In conclusion, by integrating these features seamlessly, the software empowers users to manage and track their recipes while promoting healthy eating habits through informed decision-making.


# References
F. (2024, March 4). Learn C# Programming – Full Course with Mini-Projects. YouTube. https://www.youtube.com/watch?v=YrtFtdTTfv0

I. (2018, February 23). Handling Exceptions in C# - When to catch them, where to catch them, and how to catch them. YouTube. https://www.youtube.com/watch?v=LSkbnpjCEkk

T. (2018, February 5). C# - Arrays. YouTube. https://www.youtube.com/watch?v=daFdTssjm3w

P. W. M. (2016, April 3). C# Tutorial For Beginners - Learn C# Basics in 1 Hour. YouTube. https://www.youtube.com/watch?v=gfkTfcpWqAY

M. (2024, January 12). Adding a Submenu to a Menu - Visual Studio (Windows). Microsoft Learn. https://learn.microsoft.com/en-us/visualstudio/extensibility/adding-a-submenu-to-a-menu?view=vs-2022

How to add screenshot to READMEs in github repository? (n.d.). Stack Overflow. https://stackoverflow.com/questions/10189356/how-to-add-screenshot-to-readmes-in-github-repository

IAmTimCorey. (2018b, August 6). Mocking in C# Unit Tests - How To Test Data Access Code and More [Video]. YouTube. https://www.youtube.com/watch?v=DwbYxP-etMY

Mikejo. (2024, January 19). Get started with unit testing - Visual Studio (Windows). Microsoft Learn. https://learn.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest

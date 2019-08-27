# FeudalDatabaseWikiTool
A very simple C# winForms program to read XML files from the computer game **Life is Feudal** and convert them into module data pages for the game's official wiki.

This tool mainly only works for the YO version of the game, because the raw XML files are no longer readable the MMO game version of the game.
To get the MMO XML files you will have to ask the LiF staff to give you a copy of them. See the list below for which files.

# How to Use
1. Download the source code, or a pre-complied executable from the [Releases](https://github.com/Deantwo/FeudalDatabaseWikiTool/releases).
2. Open the program.
3. Click the *...* button and navigate to the desired game folder.
 - These files are required to be at these relative paths:
```
data\skill_types.xml
data\objects_types.xml
data\objects_types_Description.xml
data\recipe.xml
data\recipe_requirement.xml
```
 - These XML files are not included in the MMO version of the game anymore. You have to get the files from one of the LiF staff.
4. Select a XML files from the drop-down list.
5. Update the corresponding [`Module:*` page on the wiki](https://lifeisfeudal.gamepedia.com/index.php?title=Special%3APrefixIndex&prefix=&namespace=828) with the output text.
 - These `Module:*` pages might be protected so only wiki admins can edit them.

# Links
- Project GitHub page: https://github.com/Deantwo/FeudalDatabaseWikiTool

# Game Links
- Game's official website: https://lifeisfeudal.com/
- Game's official wiki: https://lifeisfeudal.gamepedia.com/Life_is_Feudal_Wiki
- Game's official Discord: https://discord.gg/lifeisfeudal

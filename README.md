If you have ever experienced some of your build outputs "being stuck", or wanted to share or upload your Visual Studio solutions manually, you probably know the frustration of having to go through all the folders and deleting the bin, obj and packages folders manually.

If you do, you have probably already found some extensions here on the marketplace that help you with this. Why is this different and why did I built another one?
* This one is plain and simple. Does nothing but delete these folders. You have the options to delete for the whole solution (bin,obj for every project, packages) or just for a project (bin and obj folders).
* Not another menu option hidden somewhere in the menu bar or one of its submenus. That's crowded as it is :) I added options to delete to the context menus of the project and the solution.
* Keybinding for the solution option: Ctrl+Shift+Delete.
* Communicates via the "General" pane of the output window. No dialogs, messageboxes or other UI elements.

When you download, you have these two options:

![](https://dotnetfalconcontent.blob.core.windows.net/a-visual-studio-extension-to-really-clean-your-projects/solutionoptions.png)

![](https://dotnetfalconcontent.blob.core.windows.net/a-visual-studio-extension-to-really-clean-your-projects/projectoptions.png)

If you like the extension, you can download it from the marketplace: https://marketplace.visualstudio.com/items?itemName=CONWID.cleanbinext

If you have any ideas or problems, feel free to create an issue or PR.

If you want to know more about the motivation behind this little extension or want to know some of the technical details, check out my related blog post here: https://dotnetfalcon.com/a-visual-studio-extension-to-really-clean-your-projects
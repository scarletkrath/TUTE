# TUTE
TUTE: The Useless Text Editor is my first programming project. It's a terminal text editor like vim or nano, written in C#. Right now it supports:
  - Copying and pasting
  - Swapping lines
  - Saving and loading simple text files (from the desktop)
  - Limited undoing and redoing
  - Editing lines

# How to use
You can add a line by writing something and pressing enter. Then, there are many commands.

| Command | Function | Parameters |
| --- | --- | --- |
| `/save` | Saves the file to your desktop | `/save {filename}` |
| `/load` | Loads a file from your desktop | `/load {filename} {method}` |
| `/undo` | Removes the last line written | `/undo` |
| `/redo` | Readds the last line you've undone | `/redo` |
| `/copy` | Copies a line | `/copy {line}` |
| `/paste` | Pastes a line | `/paste {method} {line}` |
| `/edit` | Edits the conent of a line | `/edit {line}` |
| `/del` | Removes a specific line | `/del {line}` |
| `/exit` | Exits TUTE, warns you if not saved | `/exit` |
| `/move` | Swaps the position of two lines | `/move {lineOne} {lineTwo}` |
| `/clear` | Clears the screen | `/clear` |

The `{method}` of a command is a letter implying how to use the command. Right now, there's only `a` for "append" and `r` for "replace" in `/load` and in `/paste`.

# TODO
- Multiple redos
- Status bar
- Code optimization
- Fix some error message bugs

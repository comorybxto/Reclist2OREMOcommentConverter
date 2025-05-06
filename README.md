# JPN Reclist to OREMO-comment Converter (v1.0)

Reclist2OREMOcommentConverter is a console application designed for use with UTAU and OpenUtau.
It converts Japanese reclists between kana and romaji formats and generates an OREMO-comment file (`OREMO-comment.txt`) based on the input reclist.

## Features
- Convert **Kana reclists** to **Romaji comments**.
- Convert **Romaji reclists** to **Kana comments**.
- Automatically handles invalid or empty lines.
- Outputs results in a format compatible with OREMO.

## Requirements
- **.NET Framework 4.7.2** or higher.
- Reclist files encoded in **Shift-JIS (ANSI)**.

## How to Use
1. Run the application.
2. Choose an option:
   - `1)` Convert Kana reclist to Romaji comment.
   - `2)` Convert Romaji reclist to Kana comment.
3. Enter the name of the input text file (without the `.txt` extension). Ensure the file exists in the same directory as the executable.
4. The application will process the file and generate `OREMO-comment.txt` in the same directory.

## Notes
- Duplicate or invalid lines are marked with `*` in the output.
- Ensure the input file is properly encoded in Shift-JIS to avoid encoding issues.

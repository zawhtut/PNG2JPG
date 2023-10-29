# PNG2JPG

## Description

PNG2JPG is a simple console application that converts all PNG files in a specified folder to JPEG format.

## Features

- Converts all PNG files in a folder to JPG.
- Option to delete the original PNG files after conversion.
- Displays real-time processing status with a spinner animation.

## Requirements

- .NET SDK
- SixLabors.ImageSharp NuGet package

## Installation

1. Clone this repository: `git clone https://github.com/yourusername/PNG2JPG.git`
2. Navigate to the project folder: `cd PNG2JPG`
3. Run `dotnet restore` to install required packages.

## Usage

To run the program, navigate to the project folder and execute the following command:

\```bash
dotnet run -- <folder_path> [--delete]
\```

- `<folder_path>`: Path to the folder containing PNG files you want to convert.
- `--delete`: Optional flag to delete original PNG files after conversion.

### Example:

\```bash
dotnet run -- /Users/username/Desktop/test_images --delete
\```

This will convert all PNG images in the `test_images` folder on the desktop to JPG and delete the original PNG files.

## Help

To display help information, use the `-h` or `--help` option:

\```bash
dotnet run -- -h
\```

or

\```bash
dotnet run -- --help
\```

## License

This project is open-source, available under the MIT License.

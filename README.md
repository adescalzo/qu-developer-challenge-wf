# Qu Developer challenge: Word Finder

## Analysis and Evaluation

### Get the text of the matrix

It was the first challenge. Because it is the source of the text, to search each word (horizontally and vertically).

To solve it, I created some extensions to get this data. Then included in the constructor of the class to keep this information for each request to find words.

### Validation

Some validations have been included in the constructor of the class to avoid working with an invalid matrix.

### Search words and performance

Having the text from the matrix, the last challenge was to figure out the best efficient way to search these words in the text.
To achieve it, I developed and researched different performance ways to do it, and evaluated each of them with the Benchmark library.
Finally, having the best evaluated option, and according to the latest C# enhancements. The Span method gave me the best solution.
Thereafter, I created a service to give support to the WordFinder class.

### Testing

Unit testing was included for each component that required it.

### Solution and projects

- QuWordFinder.Console: It has the evaluation of the different options and evaluation to search for words in a text.
- QuWordFinder.Application: It is the main project that has solution in the file WordFinder.cs. Furthermore, it includes the other components required for it.
- QuWordFinder.Application.Tests: The project with all the unit tests for QuWordFinder.Application project.

## Information

- Name: Andrés Descalzo.
- Profile: [LinkedIn andresdescalzo](https://www.linkedin.com/in/andresdescalzo/)
- Date: Dic-21-2024

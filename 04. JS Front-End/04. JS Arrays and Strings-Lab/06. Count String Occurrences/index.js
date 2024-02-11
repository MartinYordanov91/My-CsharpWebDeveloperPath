function wordSearch(text, word) {
  console.log(text.split(" ").filter((x) => x === word).length);
}

wordSearch("This is a word and it also is a sentence", "is");
wordSearch(
  "softuni is great place for learning new programming languages",
  "softuni"
);

function wordCompletion(words, text) {
  let wordsArr = words.split(", ");
  let textArr = text.split(" ");

  for (let index = 0; index < wordsArr.length; index++) {
    let curentWords = wordsArr[index];
    let curendLength = "*".repeat(curentWords.length);

    for (let index = 0; index < textArr.length; index++) {
      if (textArr[index] === curendLength) {
        textArr[index] = curentWords;
      }
    }
  }

  console.log(textArr.join(" "));
}

wordCompletion(
  "great",
  "softuni is ***** place for learning new programming languages"
);
wordCompletion(
  "great, learning",
  "softuni is ***** place for ******** new programming languages"
);

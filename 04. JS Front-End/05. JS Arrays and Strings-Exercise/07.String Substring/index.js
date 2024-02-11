function findWord(word, text) {
  let masive = text.toLowerCase().split(" ");
  let flag = false;
  for (let index = 0; index < masive.length; index++) {
    if (masive[index] === word) {
      flag = true;
    }
  }
  console.log(flag ? word : `${word} not found!`);
}

findWord("javascript", "JavaScript is the best programming language");
findWord("python", "JavaScript is the best programming language");

function solve(input) {
  let words = input
    .toLowerCase()
    .split(" ")
    .reduce((acc, curent) => {
      if (acc[curent] === undefined) {
        acc[curent] = 0;
      }
      acc[curent]++;
      return acc;
    }, {});

  const filteredWords = Object.entries(words).filter(([key, value]) => {
    return value % 2 !== 0;
  });

  const result = Object.fromEntries(filteredWords);
  const wordResult = [];
  
  input
    .toLowerCase()
    .split(" ")
    .forEach((word) => {
      if (result[word] !== undefined) {
        wordResult.push(word);
        delete result[word];
      }
    });

  console.log(wordResult.join(" "));
}

solve("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
solve("Cake IS SWEET is Soft CAKE sweet Food");

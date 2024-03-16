function solve(input) {
  let wordsTrack = input.reduce((acc, curent, i) => {
    if (i === 0) {
      let [...arr] = curent.split(" ");
      arr.forEach((element) => {
        acc[element] = 0;
      });
    } else {
      if (acc[curent] !== undefined) {
        acc[curent] += 1;
      }
    }

    return acc;
  }, {});

  Object.entries(wordsTrack)
    .sort((a, b) => b[1] - a[1])
    .forEach(([key, value]) => {
      console.log(`${key} - ${value}`);
    });
}

solve([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);

solve([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);

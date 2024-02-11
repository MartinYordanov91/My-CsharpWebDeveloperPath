function NthElementFromMasive(array, step) {
  let results = [];
  for (let index = 0; index < array.length; index += step) {
    results.push(array[index]);
  }
  return results;
}

NthElementFromMasive(["5", "20", "31", "4", "20"], 2);
NthElementFromMasive(["dsa", "asd", "test", "tset"], 2);
NthElementFromMasive(["1", "2", "3", "4", "5"], 6);

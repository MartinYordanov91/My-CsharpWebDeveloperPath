function sortingNumbers(array) {
  let sortedArray = array.sort((a, b) => a - b);
  let output = [];
  while (sortedArray.length > 0) {
    sortedArray.length > 0 ? output.push(sortedArray.shift()) : "";
    sortedArray.length > 0 ? output.push(sortedArray.pop()) : "";
  }
  return output;
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);

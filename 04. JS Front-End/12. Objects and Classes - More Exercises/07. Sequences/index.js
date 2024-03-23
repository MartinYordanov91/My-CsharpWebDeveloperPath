function solve(input) {
    const uniqueArrays = new Map();
  
    input.forEach((arrStr) => {
      const arr = JSON.parse(arrStr);
      const sortedArr = arr.slice().sort((a, b) => b - a);
      const arrString = JSON.stringify(sortedArr);
  
      if (!uniqueArrays.has(arrString)) {
        uniqueArrays.set(arrString, sortedArr);
      }
    });
  
    const sortedUniqueArrays = [...uniqueArrays.values()].sort((a, b) => {
      if (a.length !== b.length) {
        return a.length - b.length;
      } else {
        return input.indexOf(JSON.stringify(a)) - input.indexOf(JSON.stringify(b));
      }
    });
  
    sortedUniqueArrays.forEach((arr) => {
      console.log(`[${arr.join(", ")}]`);
    });
  }

solve([
  "[-3, -2, -1, 0, 1, 2, 3, 4]",
  "[10, 1, -17, 0, 2, 13]",
  "[4, -3, 3, -2, 2, -1, 1, 0]",
]);

solve([
  "[7.14, 7.180, 7.339, 80.099]",
  "[7.339, 80.0990, 7.140000, 7.18]",
  "[7.339, 7.180, 7.14, 80.099]",
]);

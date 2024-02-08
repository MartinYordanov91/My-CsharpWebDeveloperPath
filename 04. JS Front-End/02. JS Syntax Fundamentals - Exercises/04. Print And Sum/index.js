function addingConsecutiveNumbers(startNumber, endNumber) {
  const arr = [];
  let sum = 0;

  for (let index = startNumber; index <= endNumber; index++) {
    arr.push(index);
    sum += index;
  }
  console.log(arr.join(" "));
  console.log(`Sum: ${sum}`);
}

addingConsecutiveNumbers(5, 10);
addingConsecutiveNumbers(0, 26);
addingConsecutiveNumbers(50, 60);

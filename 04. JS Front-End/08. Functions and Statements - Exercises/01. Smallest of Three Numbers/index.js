function returnTheLeast(...numbers) {
  numbers.sort((a, b) => a - b);
  console.log(numbers[0]);
}

returnTheLeast(10, 20, 1, 5, 2);

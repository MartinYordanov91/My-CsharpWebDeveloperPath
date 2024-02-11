function subtractionEvenOdd(array) {
  let even = 0;
  let odd = 0;
  for (let index = 0; index < array.length; index++) {
    array[index] % 2 == 0 ? (even += array[index]) : (odd += array[index]);
  }
  console.log(even - odd);
}

subtractionEvenOdd([1,2,3,4,5,6])
subtractionEvenOdd([3,5,7,9])
subtractionEvenOdd([2,4,6,8,10])
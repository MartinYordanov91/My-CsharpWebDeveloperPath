function materialsPyramidCalculation(base, increment) {
  let size = base;
  let stone = 0;
  let marble = 0;
  let lapis = 0;
  let gold = 0;
  let step = 0;

  function calkolateStone(curentSize) {
    curentSize -= 2;
    return curentSize * curentSize;
  }

  function calkolateLining(curentSize) {
    curentSize -= 2;
    return curentSize * 4 + 4;
  }

  while (true) {
    if (size < 1) {
      break;
    }
    step++;
    if (size <= 2) {
      size === 2 ? (gold = 4) : (gold = 1);
      break;
    }

    if (step % 5 === 0) {
      lapis += calkolateLining(size);
      stone += calkolateStone(size);
    } else {
      marble += calkolateLining(size);
      stone += calkolateStone(size);
    }

    size -= 2;
  }

  console.log(`Stone required: ${Math.ceil(stone * increment)}`);
  console.log(`Marble required: ${Math.ceil(marble * increment)}`);
  console.log(`Lapis Lazuli required: ${Math.ceil(lapis * increment)}`);
  console.log(`Gold required: ${Math.ceil(gold * increment)}`);
  console.log(`Final pyramid height: ${Math.floor(step * increment)}`);
}

materialsPyramidCalculation(11, 1);
materialsPyramidCalculation(11, 0.75);
materialsPyramidCalculation(12, 1);
materialsPyramidCalculation(23, 0.5);

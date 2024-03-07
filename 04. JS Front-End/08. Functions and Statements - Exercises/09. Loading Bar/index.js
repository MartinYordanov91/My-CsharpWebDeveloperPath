function visualLoadingBar(percent) {

  if (percent === 100) {
    console.log("100% Complete!");
    console.log("[%%%%%%%%%%]");
    return;
  }

    let bar = '%'.repeat(percent/10) + '.'.repeat(10-(percent/10)) 
    console.log(`${percent}% [${bar}]`)
    console.log("Still loading...")
}

visualLoadingBar(30)
visualLoadingBar(50)
visualLoadingBar(100)
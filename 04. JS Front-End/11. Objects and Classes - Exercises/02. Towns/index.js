function solve(input) {
  let towns = input.reduce((acc, curent) => {
    const [town, latitude, longitude] = curent.split(" | ");

    acc.push({
      town,
      latitude: Number(latitude).toFixed(2),
      longitude: Number(longitude).toFixed(2),
    });
    return acc;
  }, []);

 towns.forEach(element => {
    console.log(element)
 });
}

solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);

function solve(input) {
  let movies = input.reduce((acc, curent) => {
    if (curent.includes("addMovie")) {
      let name = curent.replace("addMovie " , '');
      let movie = {
        name,
      };
      acc.push(movie);
    }

    if (curent.includes("directedBy")) {
      const [movieName, directed] = curent.split(" directedBy ");
      const movie = acc.find((movie) => movie.name === movieName);

      if (movie) {
        movie.director = directed;
      }
    }

    if (curent.includes("onDate")) {
      const [movieName, movieDate] = curent.split(" onDate ");
      const movie = acc.find((movie) => movie.name === movieName);

      if (movie) {
        movie.date = movieDate;
      }
    }
    return acc;
  }, []);

  let filterMovies = movies.filter(
    (movie) => movie.name && movie.director && movie.date
  );

  filterMovies.forEach((element) => {
    console.log(JSON.stringify(element));
  });
}

solve([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);

import { useEffect, useState } from "react";

import MoviesList from "./features/movies/components/MoviesList";
import type Movie from "./features/movies/models/movie.model";

function App() {
	// States
	// <AppState is the data type of movies>
	const [movies, setMovies] = useState<AppState>({});

	useEffect(function () {
		const inTheaters: Movie[] = [
			{
				id: 1,
				title: "Alien",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/c/c3/Alien_movie_poster.jpg",
			},
			{
				id: 2,
				title: "Predator",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/9/95/Predator_Movie.jpg",
			},
		];

		const upcomingReleases: Movie[] = [
			{
				id: 3,
				title: "Avatar: Fire and Ash",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/4/43/Avatar_Fire_and_Ash_first_poster.jpeg",
			},
			{
				id: 4,
				title: "Spider-Man: Brand New Day",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/thumb/4/40/Spider-Man_Brand_New_Day_logo.png/500px-Spider-Man_Brand_New_Day_logo.png",
			},
		];
		// Wait two seconds before setting the state.
		setTimeout(() => {
			setMovies({ inTheaters, upcomingReleases });
		}, 1000);
	}, []);

	return (
		<>
			<h3>In Theatres</h3>
			<MoviesList movies={movies.inTheaters} />

			<h3>Upcoming Releases</h3>
			<MoviesList movies={movies.upcomingReleases} />
		</>
	);
}

interface AppState {
	inTheaters?: Movie[];
	upcomingReleases?: Movie[];
}

export default App;

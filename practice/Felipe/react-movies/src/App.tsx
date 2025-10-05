// React
import { useState, useEffect } from "react";

// Movies components
import MoviesList from "./features/movies/components/MoviesList";
import type Movie from "./features/movies/models/movie.model";

// Other components
import Button from "./components/Button";

function App() {
	// States
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

		const upComingReleases: Movie[] = [
			{
				id: 3,
				title: "Avatar: Fire and Ash",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/4/43/Avatar_Fire_and_Ash_first_poster.jpeg",
			},
			{
				id: 4,
				title: "Predator: Badlands",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/9/90/Predator_Badlands_Poster.jpg",
			},
		];
		setTimeout(() => {
			setMovies({ inTheaters, upComingReleases });
		}, 1000);
	}, []);

	return (
		<div className="container">
			<Button>Click me</Button>
			<h3>In Theaters</h3>
			<MoviesList movies={movies.inTheaters} />
			<h3>Upcoming Releases</h3>
			<MoviesList movies={movies.upComingReleases} />
		</div>
	);
}

interface AppState {
	inTheaters?: Movie[];
	upComingReleases?: Movie[];
}

export default App;

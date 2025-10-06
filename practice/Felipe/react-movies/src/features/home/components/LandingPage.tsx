// React
import { useState, useEffect } from "react";

// Movies components
import MoviesList from "../../movies/components/MoviesList";
import type Movie from "../../movies/models/movie.model";
import type LandingPageDTO from "../models/LandingPageDTO";

import ActorsList from "../../actors/components/ActorsList";
import type Actor from "../../actors/models/actor.model";

export default function LandingPage() {
	// States
	const [movies, setMovies] = useState<LandingPageDTO>({});
	//const [actors, setActors] = useState<LandingPageDTO>({});
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
			{
				id: 3,
				title: "Rambo",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/5/52/Rambo_%282008%29_poster.jpg",
			},
		];
		1;
		const upComingReleases: Movie[] = [
			{
				id: 4,
				title: "Avatar: Fire and Ash",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/4/43/Avatar_Fire_and_Ash_first_poster.jpeg",
			},
			{
				id: 5,
				title: "Predator: Badlands",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/9/90/Predator_Badlands_Poster.jpg",
			},
			{
				id: 6,
				title: "Tron: Ares",
				poster:
					"https://upload.wikimedia.org/wikipedia/en/0/06/Tron_Ares_poster.jpg",
			},
		];

		// const actors: Actor[] = [
		// 	{
		// 		id: 1,
		// 		actorName: "Brad Pitt",
		// 		actorImg:
		// 			"https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Brad_Pitt-69858.jpg/500px-Brad_Pitt-69858.jpg",
		// 	},
		// ];

		setTimeout(() => {
			setMovies({ inTheaters, upComingReleases });

			//setActors({ actors });
		}, 1000);
	}, []);

	return (
		<>
			<h3>In Theaters</h3>
			<MoviesList movies={movies.inTheaters} />
			<h3>Upcoming Releases</h3>
			<MoviesList movies={movies.upComingReleases} />

			{/* <ActorsList actors={actors.actors} /> */}
		</>
	);
}

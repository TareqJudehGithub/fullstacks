// Models
import type { JSX } from "react";
import type Movie from "../models/movie.model";

// Styling
import styles from "./DisplayMovie.module.css";

export default function DisplayMovie(props: DisplayMovieProps): JSX.Element {
	// Destructuring variables from props.movie
	const { id, title, poster } = props.movie;

	const blindLink = () => `/movie/${id}`;

	return (
		<div className={styles.div}>
			<a href={blindLink()}>
				<img src={poster} alt="Alien movie poster" />
			</a>
			<a href={blindLink()}>
				<p>{title}</p>
			</a>
		</div>
	);
}

interface DisplayMovieProps {
	movie: Movie;
}

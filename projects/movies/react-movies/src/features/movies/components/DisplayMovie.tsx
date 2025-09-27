import type Movie from "../models/movie.model";

import styles from "./DisplayMovie.module.css";

export default function DisplayMovie(props: DisplayMovieProps) {
	// Alien movie link details
	const buildLink = () => `/movie/${[props.movie.id]}`;

	return (
		<div className={styles.div}>
			<a href={buildLink()}>
				<img src={props.movie.poster} alt="Aliens movies poster" />
			</a>
			<p>
				<a href={buildLink()}>{props.movie.title}</a>
			</p>
		</div>
	);
}
interface DisplayMovieProps {
	movie: Movie;
}

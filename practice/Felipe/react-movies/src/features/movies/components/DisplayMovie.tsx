// React
import type { JSX } from "react";
// React Router
import { NavLink } from "react-router-dom";

// Models
import type Movie from "../models/movie.model";

// Styling
import styles from "./DisplayMovie.module.css";

export default function DisplayMovie(props: DisplayMovieProps): JSX.Element {
	// Destructuring variables from props.movie
	const { id, title, poster } = props.movie;

	const moviePage = () => `/movie/${id}`;

	return (
		<div className={styles.div}>
			<NavLink to={moviePage()}>
				<img src={poster} alt="Alien movie poster" />
			</NavLink>
			<NavLink to={moviePage()}>
				<p>{title}</p>
			</NavLink>
		</div>
	);
}

interface DisplayMovieProps {
	movie: Movie;
}

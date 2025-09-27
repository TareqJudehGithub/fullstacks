import type Movie from "../models/movie.model";
import DisplayMovie from "./DisplayMovie";
import styles from "./MoviesList.module.css";

export default function MoviesList(props: MoviesListProps) {
	if (!props.movies) {
		return <h3>Loading please wait..</h3>;
	} else if (props.movies.length === 0) {
		return <h3>There are no movies!</h3>;
	} else {
		return (
			<div className={styles.div}>
				{props.movies.map((movie) => (
					<DisplayMovie key={movie.id} movie={movie} />
				))}
			</div>
		);
	}
}

interface MoviesListProps {
	movies?: Movie[];
}

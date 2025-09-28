import type Movie from "../models/movie.model";
import DisplayMovie from "./DisplayMovie";
import GenericList from "./GenericList";
import styles from "./MoviesList.module.css";

export default function MoviesList(props: MoviesListProps) {
	return (
		<GenericList
			list={props.movies}
			emptyListUI={<h3>MOVIES LIST IS EMPTY!</h3>} // Overrides the custom msg in GenericList
		>
			<div className={styles.div}>
				{props.movies?.map((movie) => (
					<DisplayMovie key={movie.id} movie={movie} />
				))}
			</div>
		</GenericList>
	);
}

interface MoviesListProps {
	movies?: Movie[];
}

/* 
Before using GenericList component
// if (!props.movies) {
	// 	return <h3>Loading please wait..</h3>;
	// } else if (props.movies.length === 0) {
	// 	return <h3>There are no movies!</h3>;
	// } else {
	// 	return (
	// 		<div className={styles.div}>
	// 			{props.movies.map((movie) => (
	// 				<DisplayMovie key={movie.id} movie={movie} />
	// 			))}
	// 		</div>
	// 	);
	// }

	*/

// React

// Components
import DisplayMovie from "./DisplayMovie";

// Models
import type Movie from "../models/movie.model";

//Styling
import styles from "./MoviesList.module.css";

import GenericList from "../../../components/GenericList";

export default function MoviesList(props: MoviesListProps) {
	// In case moviesList is still loading or empty
	return (
		<GenericList list={props.movies}>
			<div className={styles.div}>
				{props.movies?.map((movie) => (
					<DisplayMovie key={movie.id} movie={movie} />
				))}
			</div>
		</GenericList>
	);
}

interface MoviesListProps {
	movies: Movie[] | undefined;
}

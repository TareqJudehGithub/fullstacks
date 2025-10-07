import type { JSX } from "react";
import { useParams, NavLink } from "react-router-dom";

export default function MovieDetails(): JSX.Element {
	const { id } = useParams();
	return (
		<>
			<p>MovieDetails: {id}</p>

			{/* 

			My own code: link to EditMovie
			<NavLink className="nav-link" to={`/movies/edit/${id}`}>
				Edit Movie
			</NavLink> 
			*/}
		</>
	);
}

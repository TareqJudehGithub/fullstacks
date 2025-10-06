// React
import { Routes, Route } from "react-router-dom";

// Features components
import LandingPage from "./features/home/components/LandingPage";
import IndexGenres from "./features/genres/components/IndexGenres";
import CreateGenre from "./features/genres/components/CreateGenre";
import EditGenre from "./features/genres/components/EditGenre";
import CreateMovie from "./features/movies/components/CreateMovie";
import EditMovie from "./features/movies/components/EditMovie";
import FilterMovies from "./features/movies/components/FilterMovies";
import MovieDetails from "./features/movies/components/MovieDetails";

export default function AppRoutes() {
	return (
		<Routes>
			<Route path="/" element={<LandingPage />} />

			<Route path="/genres" element={<IndexGenres />}>
				<Route path="Create" element={<CreateGenre />} />
				<Route path="edit" element={<EditGenre />} />
			</Route>

			{/* <Route path="/movies" element={IndexMovies}> */}
			<Route path="create" element={<CreateMovie />} />
			<Route path="edit" element={<EditMovie />} />
			<Route path="filter" element={<FilterMovies />} />
			<Route path="movie" element={<MovieDetails />} />
			{/* </Route> */}
		</Routes>
	);
}

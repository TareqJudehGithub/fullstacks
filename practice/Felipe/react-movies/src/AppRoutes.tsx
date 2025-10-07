// React
import { Routes, Route, replace, Navigate } from "react-router-dom";

import LandingPage from "./features/home/components/LandingPage";
// Features components
import IndexGenres from "./features/genres/components/IndexGenres";
import CreateGenre from "./features/genres/components/CreateGenre";
import EditGenre from "./features/genres/components/EditGenre";

import MovieDetails from "./features/movies/components/MovieDetails";
import CreateMovie from "./features/movies/components/CreateMovie";
import EditMovie from "./features/movies/components/EditMovie";
import FilterMovies from "./features/movies/components/FilterMovies";

import IndexActors from "./features/actors/components/IndexActors";
import CreateActor from "./features/actors/components/CreateActor";

import EditActor from "./features/actors/components/EditActor";
import IndexTheaters from "./features/theaters/components/IndexTheaters";
import CreateTheater from "./features/theaters/components/CreateTheater";
import EditTheater from "./features/theaters/components/EditTheater";
import HandleRouteNotFound from "./features/home/HandleRouteNotFound";

export default function AppRoutes() {
	return (
		<Routes>
			<Route path="/" element={<LandingPage />} />

			<Route path="/genres" element={<IndexGenres />}>
				<Route path="Create" element={<CreateGenre />} />
				<Route path="edit/:id" element={<EditGenre />} />
			</Route>

			{/* <Route path="/movies" element={IndexMovies}> */}
			<Route path="/movies/filter" element={<FilterMovies />} />
			<Route path="/movie/:id" element={<MovieDetails />} />
			<Route />
			<Route path="/movies/create" element={<CreateMovie />} />
			<Route path="/movies/edit/:id" element={<EditMovie />} />
			{/* </Route> */}

			<Route path="/actors" element={<IndexActors />}>
				<Route path="create" element={<CreateActor />} />
				<Route path="edit/:id" element={<EditActor />} />
			</Route>

			<Route path="/theaters" element={<IndexTheaters />}>
				<Route path="create" element={<CreateTheater />} />
				<Route path="edit/:id" element={<EditTheater />} />
			</Route>
			<Route path="*" element={<HandleRouteNotFound />} />
		</Routes>
	);
}

// React imports
import type { JSX } from "react";
import { type SubmitHandler } from "react-hook-form";
// Models
import type CreateGenre from "../models/CreateGenre.model";
// Components
import GenreForm from "./GenreForm";

export default function CreateGenre(): JSX.Element {
	// A function that can be executed when using React Hook Form
	const onSubmit: SubmitHandler<CreateGenre> = async (data) => {
		await new Promise((resolve) => setTimeout(resolve, 500));
		console.log(data);
	};

	return (
		<>
			<h4>Create Genre</h4>
			<GenreForm onSubmit={onSubmit} />
		</>
	);
}

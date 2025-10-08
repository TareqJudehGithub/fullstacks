// React
import { useEffect, useState, type JSX } from "react";
import type { SubmitHandler } from "react-hook-form";

// React Router
import { useParams } from "react-router-dom";
import type CreateGenre from "../models/CreateGenre.model";
import GenreForm from "./GenreForm";
import Loading from "../../../components/Loading";

export default function EditGenre(): JSX.Element {
	const { id } = useParams();
	// model will be undefined at the beginning by default, thats why we use a type
	// union here and set model type and value to undefined at the beginning.
	const [model, setModel] = useState<CreateGenre | undefined>(undefined);

	useEffect(() => {
		const timerId = setTimeout(() => {
			setModel({ name: "Drama " + id });
		}, 1000);
		return () => clearTimeout(timerId);
	}, [id]);

	const onSubmit: SubmitHandler<CreateGenre> = async (data) => {
		await new Promise((resolve) => setTimeout(resolve, 500));
		console.log(data);
	};
	return (
		<>
			<h3>Edit Genre</h3>
			{model ? <GenreForm onSubmit={onSubmit} model={model} /> : <Loading />}
		</>
	);
}

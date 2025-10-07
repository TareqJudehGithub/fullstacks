import type { JSX } from "react";
import { useParams } from "react-router-dom";

export default function EditTheater(): JSX.Element {
	const { id } = useParams();

	return <p>Edit Theater: {id}</p>;
}

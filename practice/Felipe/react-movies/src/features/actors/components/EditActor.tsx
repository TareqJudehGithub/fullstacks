import type { JSX } from "react";
import { useParams } from "react-router-dom";

export default function EditActor(): JSX.Element {
	const { id } = useParams();
	return <p>Edit Actor: {id}</p>;
}

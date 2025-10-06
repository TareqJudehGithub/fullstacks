// React
import type { JSX } from "react";

// Models
import type Actor from "../models/actor.model";
import DisplayActor from "./DisplayActor";

export default function actorsList(props: ActorsListProps): JSX.Element {
	return (
		<div>
			{props.actors?.map((actor) => (
				<DisplayActor key={actor.id} actor={actor} />
			))}
		</div>
	);
}

interface ActorsListProps {
	actors: Actor[] | undefined;
}

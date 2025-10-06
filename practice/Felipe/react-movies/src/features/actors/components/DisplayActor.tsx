import type Actor from "../models/actor.model";

export default function DisplayActor(props: DisplayActorProps) {
	return (
		<div>
			<img src={props.actor.actorImg} alt="Brad Pitt" />
			<a href="https://en.wikipedia.org/wiki/Brad_Pitt" target="_blank">
				{props.actor.actorName}
			</a>
		</div>
	);
}

interface DisplayActorProps {
	actor: Actor;
}

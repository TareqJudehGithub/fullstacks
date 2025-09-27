import type { Person } from "../components/Person.model";

export default function RowMemo(props: RowProps) {
	return (
		<tr>
			<td>{props.person.fullName}</td>
			<td>{props.person.fullName}</td>
			<td>
				<button onClick={() => props.remove(props.person.id)}>Del</button>
			</td>
		</tr>
	);
}

interface RowProps {
	person: Person;
	remove: (id: number) => void;
}

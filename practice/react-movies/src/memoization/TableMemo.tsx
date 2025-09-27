import type { Person } from "../components/Person.model";
import Row from "./RowMemo";

export default function TableMemo(props: TableProps) {
	// const peopleSource: Person[] = [
	// 	{ id: 1, fullName: "John Smith", department: "HR" },
	// 	{ id: 2, fullName: "Sarah Adams", department: "IT" },
	// 	{ id: 3, fullName: "Jessie James", department: "Acc" },
	//   { id: 4, fullName: "Paulo Morino", department: "Sal" },

	// ];
	return (
		<table>
			<thead>
				<tr>
					<th>Name</th>
					<th>Department</th>
					<th>Actions</th>
				</tr>
			</thead>
			<tbody>
				{props.person.map((p) => (
					<Row key={p.id} person={p} remove={props.onDelPerson} />
				))}
			</tbody>
		</table>
	);
}

interface TableProps {
	person: Person[];
	onDelPerson: (id: number) => void;
}

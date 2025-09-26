export default function ContentProjection(props: ContentProjectionProps) {
	return (
		<>
			<h3>Superior part</h3>
			<p>{props.children}</p>
			<h3>Superior part</h3>
		</>
	);
}

interface ContentProjectionProps {
	children: string;
}

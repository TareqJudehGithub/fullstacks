export default function ContentProjection2(props: ContentProjection2Props) {
	return (
		<>
			<header>{props.header}</header>
			<main>{props.main}</main>
			<footer>{props.footer}</footer>
		</>
	);
}

interface ContentProjection2Props {
	header: React.ReactNode;
	main: React.ReactNode;
	footer: React.ReactNode;
}

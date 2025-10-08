// React imports
import type { JSX } from "react";
import { useForm, type SubmitHandler } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import firstLetterUppercase from "../../../validations/firstLetterUppercase";
import { NavLink } from "react-router-dom";
import Button from "../../../components/Button";

// Models
import type CreateGenre from "../models/CreateGenre.model";

export default function GenreForm(props: GenreFormProps): JSX.Element {
	const {
		register,
		handleSubmit,
		formState: { errors, isSubmitting },
	} = useForm<CreateGenre>({
		resolver: yupResolver(validationRules),
		mode: "onChange",
		// if props model is not present then make name default value ""
		defaultValues: props.model ?? { name: "" },
	});

	return (
		<form onSubmit={handleSubmit(props.onSubmit)}>
			<div className="form-group">
				<label htmlFor="name">Name</label>
				<input
					className="form-control"
					type="text"
					autoFocus
					{...register("name")}
					autoComplete="off"
				/>
				{errors.name && <p className="error">{errors.name.message}</p>}
			</div>

			<div className="mt-2">
				{/* If the form is not valid to submit, or is submitting, then disable the Button. */}
				<Button type="submit" disabled={isSubmitting}>
					{isSubmitting ? "Sending..." : "Send"}
				</Button>

				<NavLink to="/genres" className="btn btn-bg-secondary ms-2">
					Cancel
				</NavLink>
			</div>
		</form>
	);
}

interface GenreFormProps {
	onSubmit: SubmitHandler<CreateGenre>;
	model?: CreateGenre;
}

const validationRules = yup.object({
	name: yup
		.string()
		.required("Name is required!")
		.test(firstLetterUppercase()),
});

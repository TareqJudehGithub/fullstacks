// React
import type { JSX } from "react";
import { useForm, type SubmitHandler } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import firstLetterUppercase from "../../../validations/firstLetterUppercase";
import Button from "../../../components/Button";
import { data, NavLink } from "react-router-dom";
export default function CreateActor(): JSX.Element {
	const {
		register,
		handleSubmit,
		formState: { errors, isSubmitting },
	} = useForm<FormType>({
		resolver: yupResolver(validationRules),
		mode: "onSubmit",
	});
	const onSubmit: SubmitHandler<FormType> = async (data) => {
		await new Promise((resolve) => setTimeout(resolve, 500));
		console.log(data);
	};

	return (
		<form onSubmit={handleSubmit(onSubmit)}>
			<div className="form-group">
				<label htmlFor="actorName">Actor Name</label>
				<input
					className="form-control"
					type="text"
					{...register("actorName")}
					name="actorName"
				/>
				{errors.actorName && (
					<p className="error">{errors.actorName.message}</p>
				)}
			</div>
			<div className="mt-2">
				{/* If the form is not valid to submit, or is submitting, then disable the Button. */}
				<Button type="submit" disabled={isSubmitting}>
					{isSubmitting ? "Sending..." : "Send"}
				</Button>
				<NavLink to="/actors" className="btn btn-bg-secondary ms-2">
					Cancel
				</NavLink>
			</div>
		</form>
	);
}

interface FormType {
	actorName: string;
}

const validationRules = yup.object({
	actorName: yup
		.string()
		.required("Actor name is required!")
		.test(firstLetterUppercase()),
});

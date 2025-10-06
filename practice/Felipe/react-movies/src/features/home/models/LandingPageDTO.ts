import type Actor from "../../actors/models/actor.model";
import type Movie from "../../movies/models/movie.model";

export default interface LandingPageDTO {
	inTheaters?: Movie[];
	upComingReleases?: Movie[];
	// actors?: Actor[];
}

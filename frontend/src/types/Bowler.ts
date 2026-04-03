// matches the json properties returned from the bowler get endpoint
export interface Bowler {
    bowlerFullName: string;
    teamName: string;
    address: string;
    city: string;
    state: string;
    zip: string;
    phoneNumber: string;
}

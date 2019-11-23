import { Room } from './room.model';
import { Preference } from './preference.model';

export class User{
    id: number;
    name: string;
    password:string;
    room: Array<Room>;
    preferences: Array<Preference>; 
}
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class StorageHelperService {
    setAsLocal(name: string, storeString: string) {
        localStorage.setItem(this.encodeString(name), this.encodeString(storeString));
    }

    setAsSession(name: string, storeString: string) {
        sessionStorage.setItem(this.encodeString(name), this.encodeString(storeString));
    }

    getFromLocal(name: string) {
        return this.decodeString(localStorage.getItem(this.encodeString(name)));
    }

    getFromSession(name: string) {
        return this.decodeString(sessionStorage.getItem(this.encodeString(name)));
    }

    removeFromLocal(name: string) {
        localStorage.removeItem(this.encodeString(name));
    }

    removeFromSession(name: string) {
        sessionStorage.removeItem(this.encodeString(name));
    }

    encodeString(stringData: string) {
        return btoa(stringData);
    }

    decodeString(stringData: string | null): string {
        if (stringData != null) {
            return atob(stringData);
        }
        return "";
    }
}
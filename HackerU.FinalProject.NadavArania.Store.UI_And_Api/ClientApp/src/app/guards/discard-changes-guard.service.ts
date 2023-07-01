import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { SettingsComponent } from '../components/settings/settings.component';

export interface IDiscardChangesInterface {
  canExit: () => boolean;
}

@Injectable({
  providedIn: 'root'
})
export class DiscardChangesGuardService implements CanDeactivate<IDiscardChangesInterface> {

  //Handle Discard Changes Option
  constructor() { }
  canDeactivate(component: IDiscardChangesInterface): boolean {
    return component.canExit();
    }
}

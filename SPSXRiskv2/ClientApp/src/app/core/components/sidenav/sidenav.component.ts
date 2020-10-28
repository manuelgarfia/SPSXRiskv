import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Router } from '@angular/router';
import { MediaMatcher } from '@angular/cdk/layout';
import { XRSKUser } from 'src/app/core/models/xrskuser.model';
import { XRSKpanelItem } from 'src/app/core/models/xrskmenuPanel.model';
import { XRSKmenuItem } from 'src/app/core/models/xrskmenuItem.model';
import { Observable } from 'rxjs';

import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit, OnDestroy {

  mobileQuery: MediaQueryList;

  public menuPanel: XRSKpanelItem[];
  public menuPanel$: Observable<XRSKpanelItem[]>;
  public learningPanel: XRSKpanelItem[];
  public ejemplosPanel: XRSKpanelItem[];

  public currentUser: XRSKUser;
  isLoggedIn$: Observable<boolean>;
  currentUser$: Observable<XRSKUser>;

  public modalOptions: any;
  modalRef: MDBModalRef;

  panelOpenState = false;
  
  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, public auth: AuthenticationService, private readonly router: Router, public modalservice: MDBModalService,) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);

  }

  ngOnInit(): void {
    //TODO obtener la estructura de menú lateral de un servicio

    // Predefinimos un panel
    this.menuPanel = this.learningPanel;

    this.isLoggedIn$ = this.auth.isLoggedIn;
    this.currentUser$ = this.auth.currentUserObs;
    this.currentUser = this.auth.currentUserValue;

    //Obtenim els panels depenent de l'usuari
    this.menuPanel$ = this.auth.panelesObs;
    //this.getSecondLevel();
    
  }

  public secondLevelList: any[] = []
  public secondLevel: any[] = []

  getSecondLevel() {
    this.menuPanel$.forEach(panel => {

      for (let item of panel) {
        if (item.menu.length != 0) {
          for (let i of item.menu) {
            this.secondLevel.push(i);
          }
        }
      }
    }

      )
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  learningClick(): void {
    this.menuPanel = this.learningPanel;
  }

  ejemplosClick(): void {
    this.menuPanel = this.ejemplosPanel;
  }

  logout(): void {
    this.auth.logout();
    this.router.navigate(['/login']);
  }

  shouldRun = true;

  public isClicked: boolean = false;
  public thirdLevelOpened: boolean = false;
  public thirdLevelMenu: any[] = [];

  public routeString: string;

  onItemMenuClick(itemPrimerNivel) {

    this.secondLevel = itemPrimerNivel.menu;
    this.isClicked = !this.isClicked
    if (this.thirdLevelOpened == true) {
      this.thirdLevelOpened = false;
    }

  }


  onSecondLevel(item) {

    //Diferenciar entre usuaris pel routing
    this.currentUser$.forEach(data => {
      if (data.username == 'xrisk') {
        this.secondLevelNavigation(item);
        this.thirdLevelOpened = !this.thirdLevelOpened;
      }
    })

    this.thirdLevelMenu = item.menuItem;

    if (item.name == 'Portal Préstamos') {
      this.secondLevelNavigation(item);
    }

    this.thirdLevelOpened = !this.thirdLevelOpened;
  }

  secondLevelNavigation(item) {
    this.routeString = item.route;
    this.router.navigate(['/' + this.routeString]);
  }

  thirdLevelNavigation(item) {
    this.routeString = item.route;
    //this.router.navigate(['/' + this.routeString]);

    window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/Desktop2016.aspx?" + this.routeString);
  }


}


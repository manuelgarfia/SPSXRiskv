import { ChangeDetectorRef, Component, OnDestroy, OnInit, HostListener, ViewChild, ElementRef } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Router } from '@angular/router';
import { MediaMatcher } from '@angular/cdk/layout';
import { XRSKUser } from 'src/app/core/models/xrskuser.model';
import { XRSKpanelItem } from 'src/app/core/models/xrskmenuPanel.model';
import { XRSKmenuItem } from 'src/app/core/models/xrskmenuItem.model';
import { Observable, BehaviorSubject } from 'rxjs';

import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit, OnDestroy {

  mobileQuery: MediaQueryList;
  public menuPanel: XRSKpanelItem[];
  public menuPanel$: Observable<XRSKpanelItem[]>;

  @ViewChild('snav') sidenav: MatSidenav;

  public learningPanel: XRSKpanelItem[];
  public ejemplosPanel: XRSKpanelItem[];

  public currentUser: XRSKUser;
  isLoggedIn$: Observable<boolean>;
  currentUser$: Observable<XRSKUser>;

  shouldRun = true;
  private _mobileQueryListener: () => void;
  public modalOptions: any;
  modalRef: MDBModalRef;
  panelOpenState = false;

  public loginValues: any[] = [];
  preferences: any;
  saveMenu: any;

  public routeString: string;
  public menuLoaded$: Observable<boolean>;
  public isClicked: boolean = false;
  public secondLevelList: any[] = []
  public secondLevel: any[] = []
  public thirdLevelOpened: boolean = false;
  public thirdLevelMenu: any[] = [];
  

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, public auth: AuthenticationService,
    private readonly router: Router, public modalservice: MDBModalService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);

  }

  ngOnInit(): void {
    // Predefinimos un panel
    this.menuPanel = this.learningPanel;

    this.isLoggedIn$ = this.auth.isLoggedIn;
    this.currentUser$ = this.auth.currentUserObs;
    this.currentUser = this.auth.currentUserValue;

    //Obtenim els panels depenent de l'usuari
    this.menuPanel$ = this.auth.panelesObs;
    this.menuLoaded$ = this.auth.menuIsLoaded;

    //Comprobar si ja hi ha un usuari perquè detecti que el menu ja està carregat
    this.checkUser();
  }

  checkUser() {
    const currentUser = this.auth.currentUserValue;
    if (currentUser) {
      this.menuLoaded$ = this.auth.checkMenuLoaded;
    }
  }

  public show: boolean = false;
  //hide second and third level
  clickit() {
    this.sidenav.toggle();
    if (this.thirdLevelOpened == true) {
      this.thirdLevelOpened = !this.thirdLevelOpened;
    }

    if (this.isClicked == true) {
      this.isClicked = !this.isClicked;
    }
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

  getSecondLevel() {

    this.menuPanel$.forEach(panel => {
      for (let item of panel) {
        if (item.menu.length != 0) {
          for (let i of item.menu) {
            this.secondLevel.push(i);
          }
        }
      }
    })
  }

  onItemMenuClick(itemPrimerNivel) {
    this.secondLevel = itemPrimerNivel.menu;

    //Mantenir el primer nivell obert si es fa click a un altre menu
    if (this.isClicked == true) {
      this.isClicked = true;
    } else {
      this.isClicked = !this.isClicked;
    }

    //this.isClicked = !this.isClicked

    if (this.thirdLevelOpened == true) {
      this.thirdLevelOpened = false;
    }

  }

  onSecondLevel(item) {
    //Si l'usuari es xrisk, no redirigeix al xrisk antic
    this.currentUser$.forEach(data => {
      if (data.username == 'xrisk') {
        this.secondLevelNavigation(item);
        this.thirdLevelOpened = !this.thirdLevelOpened;
      }
    })

    //Mantenir el segon nivell obert si es fa click a un altre menu
    if (this.thirdLevelOpened == true) {
      this.thirdLevelOpened = true;
    } else {
      this.thirdLevelOpened = !this.thirdLevelOpened;
    }
    //Recorrer la llista per trobar el menu corresponent al que s'ha clicat
    for (let itemSecondLevel of this.secondLevel) {
      if (item.name == itemSecondLevel.name) {
        this.thirdLevelMenu = item.menuItem;
      }
    }
    //En el cas del Portal de Deuda, no dirigeix a x-risk antic
    if (item.hasRouting == true) {
      this.secondLevelNavigation(item);
    }
    //if (item.name == 'Portales Procesos') {
    //  this.secondLevelNavigation(item);
    //}

  }

  secondLevelNavigation(item) {
    this.routeString = item.route;
    this.router.navigate(['/' + this.routeString]);
  }

  thirdLevelNavigation(item) {
    var user;
    var contr;
    this.loginValues = [];
    //S'assigna la ruta a un string per tractar-la posteriorment
    this.routeString = item.route;

    //Si la ruta és de repoting, que obri directament la url sense concatenar
    if (this.routeString.startsWith('http')) {
      window.open(this.routeString);
    } else {
      //Per poder mantenir els valors d'usuari i contrasenya que venen de variables observable, els guardem
      //al localStorage i així no els perdem mentres naveguem. Si no tenim dades al localStorage, els anem
      //a buscar al server d'authenticationService
      this.preferences = JSON.parse(localStorage.getItem('LoginPreferences'));
      if (this.preferences != null) {
        this.loginValues = this.preferences.loginValues;
        for (let item of this.loginValues) {
          user = item.user;
          contr = item.password;
        }
      }

      if (this.loginValues.length == 0) {
        this.loginValues = this.auth.toSideNavLogin();
        this.preferences = { "loginValues": this.loginValues }
        localStorage.setItem('LoginPreferences', JSON.stringify(this.preferences));

        for (let item of this.loginValues) {
          user = item.user;
          contr = item.password;
        }
      }

      //Es fa el replace per introduir l'usuari i la contrasenya.
      var ruta = this.routeString.replace("xxx", user);
      ruta = ruta.replace("oys", contr);
      window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/" + ruta);

    }
  }

  logout(): void {

    //hide the third level sideNav
    if (this.thirdLevelOpened == true) {
      this.thirdLevelOpened = !this.thirdLevelOpened;
    }
    //hide the second level sideNav
    if (this.isClicked == true) {
      this.isClicked = !this.isClicked;
      this.sidenav.toggle();
    }

    this.auth.logout();
    this.router.navigate(['/login']);
  }

}


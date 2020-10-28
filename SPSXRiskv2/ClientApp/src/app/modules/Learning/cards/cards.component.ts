import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { XRSKApunteBancarioService } from 'src/app/shared/services/xrskApunteBancario.service';
import { XRSKApunteBancario, ApuntBancInformation } from 'src/app/shared/models/xrskApunteBancario.model';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component'
import { FilterHeader, FilterDetail } from '../../../shared/models/filtermodel';
import { LoadingModalComponent } from '../../../shared/components/loading-modal/loading-modal.component'
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {


  constructor(private ApunBancService: XRSKApunteBancarioService,
              public modalservice: MDBModalService) { }

  public apunBanc: any[];
  public loaded: boolean = false;
  public cardInfoList: any[];

  ngOnInit(): void {
    //this.showLoader();
    this.getCardInformation();
  }

  showLoader() {
    setTimeout(() => {
      this.loaded = true;
    }, 4000);
  }

  getCardInformation() {
    this.ApunBancService.getProcessInformation().subscribe(
      card => {
        this.cardInfoList = card as ApuntBancInformation[];
        this.loaded = true;
      },
      err => { console.log(err); }
    )
  }

  getApunBanc() {
    this.ApunBancService.getXRSKApunteBancarioList().subscribe(
      apunBanc => {
        this.apunBanc = apunBanc as XRSKApunteBancario[];
      },
      err => {
        console.log(err);
      }
    );
  }

}

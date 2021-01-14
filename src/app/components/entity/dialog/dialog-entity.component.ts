import { Component, Inject, OnInit } from '@angular/core';
import { ApiEntityService } from './../../../service/api-entity.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IEntity } from 'src/app/models/IEntity';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IDocument } from './../../../models/IDocument';
import { ApiDocumentService } from './../../../service/api-document.service';
import { ApiTaxpayerService } from './../../../service/api-taxpayer.service';
import { ITaxpayer } from './../../../models/ITaxpayer';
import { IResponse } from 'src/app/models/IResponse';

@Component({
  selector: 'app-dialog-entity',
  templateUrl: './dialog-entity.component.html',
  styleUrls: ['./dialog-entity.component.scss'],
})
export class DialogEntityComponent implements OnInit {
  public entityForm: FormGroup;
  public optionsDocuments: IDocument[];
  public optionsTaxpayer: ITaxpayer[];
  private _duration: number = 5000;
  private _isCellular: RegExp = /^((\+51)\s|(\(\+51\))\s?)?9([0-9]{2}[\s-]?){1}([0-9]{3}[\s-]?){2}$/gm;

  constructor(
    private _apiEntityService: ApiEntityService,
    private _apiDocumentService: ApiDocumentService,
    private _apiTaxpayerService: ApiTaxpayerService,
    private _formBuilder: FormBuilder,
    private _dialogRef: MatDialogRef<DialogEntityComponent>,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public entity: IEntity
  ) {}

  ngOnInit(): void {
    this._apiDocumentService.get().subscribe((res) => {
      if (res.result) {
        this.optionsDocuments = res.data;
      }
    });

    this._apiTaxpayerService.get().subscribe((res) => {
      if (res.result) {
        this.optionsTaxpayer = res.data;
      }
    });

    this.initForm();
  }

  private initForm(): void {
    this.entityForm = this._formBuilder.group({
      idEntidad: [this.entity ? this.entity.idEntidad : 0],
      idTipoDoc: [
        this.entity ? this.entity.idTipoDoc.toString() : '',
        [Validators.required],
      ],
      numDocumento: [
        this.entity ? this.entity.numDocumento : '',
        [Validators.required],
      ],
      razonSocial: [
        this.entity ? this.entity.razonSocial : '',
        [Validators.required],
      ],
      nombreComercial: [
        this.entity ? this.entity.nombreComercial : '',
        [Validators.required],
      ],
      idContribuyente: [
        this.entity ? this.entity.idContribuyente.toString() : '',
        [Validators.required],
      ],
      direccion: [this.entity ? this.entity.direccion : ''],
      telefono: [
        this.entity ? this.entity.telefono : '',
        [Validators.pattern(this._isCellular)],
      ],
      estado: [true],
    });
  }

  async onSave(): Promise<void> {
    if (this.entityForm.valid) {
      const entity = { ...this.entityForm.value };
      entity.idContribuyente = parseInt(entity?.idContribuyente ?? 0);
      entity.idTipoDoc = parseInt(entity?.idTipoDoc ?? 0);
      const newEntity: IEntity = entity as IEntity;
      let res: IResponse<any>;

      try {
        if (this.entity === null) {
          res = await this._apiEntityService.add(newEntity).toPromise();
        } else {
          res = await this._apiEntityService.update(newEntity).toPromise();
        }

        if (res.result) {
          this._snackBar.open(res.message, '', {
            duration: this._duration,
          });
          this._dialogRef.close(true);
        }
        {
          this._snackBar.open(res.message, '', {
            duration: this._duration,
          });
        }
      } catch (err) {
        this._snackBar.open('Ocurrio un error inesperado.', '', {
          duration: this._duration,
        });
        console.error(err);
      }
    }
  }
}
